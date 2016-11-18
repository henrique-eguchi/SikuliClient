/*
 * Created by SharpDevelop.
 * User: Alan
 * Date: 6/8/2014
 * Time: 9:05 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using NETSikuliClient.Sikuli_UTIL;
using Newtonsoft.Json;

namespace NETSikuliClient.Sikuli_JSON
{
	/// <summary>
	/// Description of json_Result.
	/// </summary>
	public class json_Result
	{
		public json_Result()
		{
		}
		
		public String message {get; set;}
		public String result {get; set;}
        public String stacktrace { get; set; }
		
		public ActionResult ToActionResult()
		{
			if(result.Equals(ActionResult.FAIL.ToString()))
			{
				return ActionResult.FAIL;
			}
			else if(result.Equals(ActionResult.ERROR.ToString()))
			{
				return ActionResult.ERROR;
			}
            else if (result.Equals(ActionResult.PASS.ToString()))
            {
                return ActionResult.PASS;
            }
            else
			{
				return ActionResult.UNKNOWN;
			}
		}

        public static json_Result getJResult(string json)
        {
            json_Result jResult = new json_Result();

            if (json.Contains("Unable to connect to the remote server"))
            {
                jResult.message = json;
                jResult.result = ActionResult.ERROR.ToString();
                jResult.stacktrace = json;
            }
            else
            {
                jResult = JsonConvert.DeserializeObject<json_Result>(json);
            }

            return jResult;
        }
	}
}
