using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ECX.CD.DA
{
    public class DBParameter
    {
        public string FieldName;
        public SqlDbType Type;
        public object Value;

        public DBParameter(string fieldName, SqlDbType type, object value)
        {
            this.FieldName = fieldName;
            this.Type = type;
            this.Value = value;
        }
    }
}
