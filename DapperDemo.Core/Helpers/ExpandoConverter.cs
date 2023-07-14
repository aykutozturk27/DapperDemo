using System.Dynamic;
using System.Reflection;

namespace DapperDemo.Core.Helpers
{
    public static class ExpandoConverter
    {
        public static object SetParameter(object parameters)
        {
            if (parameters == null) parameters = "*";
            return parameters;
        }

        public static Dapper.DynamicParameters ConvertToExpando(object obj)
        {
            try
            {
                Dapper.DynamicParameters ReqeustedParams = (Dapper.DynamicParameters)obj;
                Dapper.DynamicParameters ReturnParams = new Dapper.DynamicParameters();
                foreach (var item in ReqeustedParams.ParameterNames)
                {
                    if ((item != "Language") && (item != "RemoveUnused"))
                    {
                        ReturnParams.Add(item, ReqeustedParams.Get<dynamic>(item));
                    }
                }
                return ReturnParams;
            }
            catch (Exception)
            {
                //Dapper.DynamicParameters ReqeustedParams = (Dapper.DynamicParameters)obj;
                Dapper.DynamicParameters ReturnParams = new Dapper.DynamicParameters();
                foreach (var item in obj.GetType().GetProperties())
                {
                    if ((item.Name != "Language") && (item.Name != "RemoveUnused"))
                    {
                        var val = obj.GetType().GetProperty(item.Name).GetValue(obj, null);
                        ReturnParams.Add(item.Name, val);
                    }
                }
                return ReturnParams;
            }




        }
        public static Object GetPropValue(this Object obj, String name)
        {
            foreach (String part in name.Split('.'))
            {
                if (obj == null) { return null; }

                Type type = obj.GetType();
                PropertyInfo info = type.GetProperty(part);
                if (info == null) { return null; }

                obj = info.GetValue(obj, null);
            }
            return obj;
        }

        private static void AddProperty(ExpandoObject expando, string propertyName, object propertyValue)
        {
            //Take use of the IDictionary implementation
            var expandoDict = expando as IDictionary<String, object>;
            if (expandoDict.ContainsKey(propertyName))
                expandoDict[propertyName] = propertyValue;
            else
                expandoDict.Add(propertyName, propertyValue);
        }
    }
}
