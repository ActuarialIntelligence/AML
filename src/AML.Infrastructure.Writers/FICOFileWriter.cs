using System;
using System.Collections.Generic;
using System.Reflection;
using AML.Domain;
using AML.Infrastructure.Writers.Interfaces;
using AML.Infrastructure.Connections.Interfaces;

namespace AML.Infrastructure.Writers
{
    public class FICOFileWriter<T,U,V> : IDataWrite<IList<FieldNameInputValuePairObject>> 
    {
        private readonly IDataWriteConnection<U> connection;
        private readonly IDataWriteConnection<V> connectionExt;
        private string path;
        private string pathExt;
        public FICOFileWriter(IDataWriteConnection<U> connection, 
            IDataWriteConnection<V> connectionExt, string path, string pathExt)
        {
            this.connection = connection;
            this.connectionExt = connectionExt;
            this.path = path;
            this.pathExt = pathExt;
        }
        public void Write(IList<FieldNameInputValuePairObject> values, string delimiter)
        {
            //var obj = new FICOFields();
            //Type type = obj.GetType();
            //PropertyInfo pi = type.GetProperty("FIRST_NAME");
            //pi.SetValue(obj, "Rajmeister", null);

                var list = new List<T>();
                var extList = new List<T>();
                foreach (var item in values)
                {

                    var obj = Activator.CreateInstance(typeof(T));
                    var extObj = Activator.CreateInstance(typeof(T));
                    foreach (FieldNameInputValuePair pair in item.FieldNameInputValuePairList)
                    {
                        
                        Type type = obj.GetType();
                        Type extType = obj.GetType();
                        PropertyInfo pi = type.GetProperty(pair.FieldName);
                        PropertyInfo extPi = extType.GetProperty(pair.FieldName);
                        if (pi != null)
                        {
                            pi.SetValue(obj, pair.FieldValue, null);
                            if (extPi != null)
                            {
                                extPi.SetValue(extObj, pair.FieldExtensionValue, null);
                            }
                        }
                    }
                    list.Add((T)obj);
                    extList.Add((T)extObj);
                }

                List<U> listOut;
                List<V> extListOut;
                CreateMappingBetweenGenericObjects(list, extList, out listOut, out extListOut);

                connection.WriteData(listOut, path, delimiter);
                connectionExt.WriteData(extListOut, pathExt, "|");


        }
        /// <summary>
        /// This is necessary because reflection needs get; set; members and filehelpers
        /// needs field like objects and as such we are creating the necessary objects.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="extList"></param>
        /// <param name="listOut"></param>
        /// <param name="extListOut"></param>
        private static void CreateMappingBetweenGenericObjects(List<T> list, List<T> extList, out List<U> listOut, out List<V> extListOut)
        {
            var config = Mappings.Mappings.CreateMapAndReturnConfig<T, U>();
            var configExt = Mappings.Mappings.CreateMapAndReturnConfig<T, V>();
            var mapper = config.CreateMapper();
            var mapperExt = configExt.CreateMapper();
            var cnt = 0;
            listOut = new List<U>();
            extListOut = new List<V>();
            foreach (var obj in list)
            {
                listOut.Add(mapper.Map<T, U>(obj));
                extListOut.Add(mapperExt.Map<T, V>(extList[cnt]));
                cnt++;
            }
        }
    }
}
