using DSPLogistics.Common.Resources.DSPObjectModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using uTinyRipper;
using uTinyRipper.Classes;
using uTinyRipper.Game.Assembly;

namespace DSPLogistics.Common.Resources
{
    public class GameDataBase
    {
        private const string ItemProtoSetName = "ItemProtoSet";
        private const string RecipeProtoSetName = "RecipeProtoSet";

        public IReadOnlyList<ItemProto> ItemSet { get; }

        public IReadOnlyList<RecipeProto> RecipeSet { get; }

        protected GameDataBase(string GameBasePath)
        {
            using (var gameStructrue = GameStructure.Load(new[] { GameBasePath }))
            {
                var assests =
                    gameStructrue
                    .FileCollection
                    .FetchAssets()
                    .Where(assest => assest.ClassID == ClassIDType.MonoBehaviour)
                    .Cast<MonoBehaviour>();
                var itemProtoSet = assests.Where(obj => obj.Name == ItemProtoSetName).FirstOrDefault();
                var itemList = MapProperties<ProtoSet<ItemProto>>(itemProtoSet.Structure);
                ItemSet = itemList.dataArray;
                var recipeProtoSet = assests.Where(obj => obj.Name == RecipeProtoSetName).FirstOrDefault();
                var recipeList = MapProperties<ProtoSet<RecipeProto>>(recipeProtoSet.Structure);
                RecipeSet = recipeList.dataArray;
            }

        }

        private static T MapProperties<T>(SerializableStructure from)
        {
            return (T)MapProperties(from, typeof(T));
        }

        private static object MapProperties(SerializableStructure from, Type tTo)
        {
            if (null == from)
            {
                return null;
            }
            var to = Activator.CreateInstance(tTo);
            DoMapping(from.Type);
            return to;

            int DoMapping(SerializableType type)
            {
                var idx = 0;
                if (null != type.Base)
                {
                    idx += DoMapping(type.Base);
                }
                foreach (var field in type.Fields)
                {
                    var prop = to.GetType().GetRuntimeProperty(field.Name);
                    var fieldVal = from.Fields[idx];
                    if (null != prop)
                    {
                        if (field.Type.Type == PrimitiveType.Complex)
                        {
                            prop.SetValue(to, ConvertComplexType(fieldVal, prop.PropertyType, field.IsArray));
                        }
                        else
                        {
                            prop.SetValue(to, ConvertType(fieldVal, field));
                        }



                        idx++;
                    }
                    else
                    {
#if DEBUG
                        throw new InvalidDataException($"Field not supported: {field.Name}");
#endif
                    }
                }
                return idx;
            }
        }

        static object ConvertComplexType(SerializableField fieldVal, Type type, bool isArray)
        {
            try
            {
                if (isArray)
                {
                    var elmType = type.GetGenericArguments()[0];
                    var arrType = typeof(List<>).MakeGenericType(elmType);
                    var ret = Activator.CreateInstance(arrType) as IList;
                    foreach (SerializableStructure record in (IAsset[])fieldVal.CValue)
                    {
                        var item = MapProperties(record, elmType);
                        ret.Add(item);
                    }
                    return ret;
                }
                else
                {
                    return MapProperties((SerializableStructure)fieldVal.CValue, type);
                }
            }
            catch (InvalidCastException)
            {
                throw new NotSupportedException();
            }
        }

        static object ConvertType(SerializableField fieldVal, in SerializableType.Field field)
        {
            if (field.IsArray)
            {
                switch (field.Type.Type)
                {
                    case PrimitiveType.Bool:
                        return (bool[])fieldVal.CValue;
                    case PrimitiveType.Char:
                        return (char[])fieldVal.CValue;
                    case PrimitiveType.SByte:
                        return (byte[])fieldVal.CValue;
                    case PrimitiveType.Byte:
                        return (byte[])fieldVal.CValue;
                    case PrimitiveType.Short:
                        return (short[])fieldVal.CValue;
                    case PrimitiveType.UShort:
                        return (ushort[])fieldVal.CValue;
                    case PrimitiveType.Int:
                        return (int[])fieldVal.CValue;
                    case PrimitiveType.UInt:
                        return (uint[])fieldVal.CValue;
                    case PrimitiveType.Long:
                        return (long[])fieldVal.CValue;
                    case PrimitiveType.ULong:
                        return (ulong[])fieldVal.CValue;
                    case PrimitiveType.Single:
                        return (float[])fieldVal.CValue;
                    case PrimitiveType.Double:
                        return (double[])fieldVal.CValue;
                    case PrimitiveType.String:
                        return (string[])fieldVal.CValue;
                    default:
                        throw new NotSupportedException(field.Type.Type.ToString());
                }
            }
            else
            {

                switch (field.Type.Type)
                {
                    case PrimitiveType.Bool:
                        return fieldVal.PValue != 0;
                    case PrimitiveType.Char:
                        return (int)(char)fieldVal.PValue;
                    case PrimitiveType.SByte:
                        return unchecked((sbyte)fieldVal.PValue);
                    case PrimitiveType.Byte:
                        return (byte)fieldVal.PValue;
                    case PrimitiveType.Short:
                        return unchecked((short)fieldVal.PValue);
                    case PrimitiveType.UShort:
                        return (ushort)fieldVal.PValue;
                    case PrimitiveType.Int:
                        return unchecked((int)fieldVal.PValue);
                    case PrimitiveType.UInt:
                        return (uint)fieldVal.PValue;
                    case PrimitiveType.Long:
                        return unchecked((long)fieldVal.PValue);
                    case PrimitiveType.ULong:
                        return fieldVal.PValue;
                    case PrimitiveType.Single:
                        return BitConverterExtensions.ToSingle((uint)fieldVal.PValue);
                    case PrimitiveType.Double:
                        return BitConverterExtensions.ToDouble(fieldVal.PValue);
                    case PrimitiveType.String:
                        return (string)fieldVal.CValue;
                    default:
                        throw new NotSupportedException(field.Type.Type.ToString());
                }
            }
        }

        public static GameDataBase Load(string GameBasePath)
        {
            if (Directory.Exists(GameBasePath))
            {
                return new GameDataBase(GameBasePath);
            }
            else
            {
                throw new DirectoryNotFoundException();
            }
        }
    }
}
