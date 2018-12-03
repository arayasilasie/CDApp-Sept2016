using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting;
using System.Data;
using System.Data.SqlClient;

namespace ECX.CD.DA
{
    public class Utilities:SQLHelper
	{
		public static Guid EnglishGuid
		{
			get
			{
				return new Guid("9ad72f55-bc00-4382-873e-0c84d6eb3850");
			}
		}

        public static StringBuilder AppendOrLikeString(string fieldName, List<string> fieldValues)
        {
            int length = fieldValues.Count;
            StringBuilder sb = new StringBuilder();

            if (length > 0)
                sb.Append("([" + fieldName + "] Like '" + fieldValues[0] + "' + '%' ");
            for (int i = 1; i < length; i++)
                sb.Append(" Or [" + fieldName + "] Like '" + fieldValues[i] + "' + '%'");

            return sb;
        }

        public static string AppendInString(string fieldName, List<string> fieldValues)
        {
            int length = fieldValues.Count;
            StringBuilder sb = new StringBuilder();
            if (length == 0)
                return "";

            if (length > 0)
                sb.Append("[" + fieldName + "] In ('" + fieldValues[0] + "' ");
            for (int i = 1; i < length; i++)
                sb.Append(" , '" + fieldValues[i] + "'");
            sb.Append(")");

            return sb.ToString();
        }

        public static string AppendInString(string fieldName, string[] fieldValues)
        {
            int length = fieldValues.Length;
            StringBuilder sb = new StringBuilder();
            if (length == 0)
                return "";

            if (length > 0)
                sb.Append(fieldName + " In ('" + fieldValues[0] + "' ");
            for (int i = 1; i < length; i++)
                sb.Append(" , '" + fieldValues[i] + "'");
            sb.Append(")");

            return sb.ToString();
        }

        public static string AppendInString(string fieldName, List<Guid> fieldValues)
        {
            int length = fieldValues.Count;
            StringBuilder sb = new StringBuilder();
            if (length == 0)
                return "";

            if (length > 0)
                sb.Append("[" + fieldName + "] In ('" + fieldValues[0].ToString() + "' ");
            for (int i = 1; i < length; i++)
                sb.Append(" , '" + fieldValues[i].ToString() + "'");
            sb.Append(")");

            return sb.ToString();
        }

        public static string AppendInString(string fieldName, List<byte> fieldValues)
        {
            int length = fieldValues.Count;
            StringBuilder sb = new StringBuilder();
            if (length == 0)
                return "";

            if (length > 0)
                sb.Append("[" + fieldName + "] In (" + fieldValues[0].ToString() + " ");
            for (int i = 1; i < length; i++)
                sb.Append(" , " + fieldValues[i].ToString() + "");
            sb.Append(")");

            return sb.ToString();
        }

        public static string AppendNotInString(string fieldName, List<string> fieldValues)
        {
            int length = fieldValues.Count;
            StringBuilder sb = new StringBuilder();
            if (length == 0)
                return "";

            if (length > 0)
                sb.Append("[" + fieldName + "] Not In ('" + fieldValues[0] + "' ");
            for (int i = 1; i < length; i++)
                sb.Append(" , '" + fieldValues[i] + "'");
            sb.Append(")");

            return sb.ToString();
        }

        public static List<string> SplitKeyword(string keyword)
        {
            List<string> ret = new List<string>();

            foreach (string s in keyword.Split(new string[] { " ", ",", ", ", " ," }, StringSplitOptions.RemoveEmptyEntries))
                if (!ret.Contains(s.Trim()))
                    ret.Add(s.Trim());

            return ret;
        }

        public static string GetWhereClause(string[] fields)
        {
            string ret = "";
            int count = fields.Length;

            if (count == 0)
                return "";

            for(int i = 0; i < count - 1;i++)
            {
                ret += (fields[i] == "") ? "" : fields[i] + " @" + fields[i] + " And ";
            }

            ret += (fields[count - 1] == "") ? "" : fields[count - 1] + " @" + fields[count - 1] + " ";

            return ret;
        }

        public static SqlCommand AddCommandParameters(DBParameter[] parameters, SqlCommand command)
        {
            int count = parameters.Length;

            for(int i = 0; i < count; i++)
            {
                if (parameters[i].Value.ToString() != "")
                {
                    command.Parameters.Add("@" + parameters[i].FieldName, parameters[i].Type).Value = parameters[i].Value;
                }
            }

            return command;
        }
    }
}
