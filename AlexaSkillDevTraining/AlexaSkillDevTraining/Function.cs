using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace AlexaSkillDevTraining
{
    public class Function
    {

        string[] messages = { 
            "Hello World",
            "Hello Alexa From CSharp",
            "C#で実装したLambdaコードからこんにちは！"
        };

        

        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public  SkillResponse FunctionHandler(SkillRequest input, ILambdaContext context)
        {
            string msg;

            switch (input.Request)
            {
                case LaunchRequest Ir:
                    msg = "こんにちは";
                    break;

                case IntentRequest ir:
                    msg = MakeResponse(ir);
                    break;
                default:
                    msg = "?";
                    break;
            }

            var response = new SkillResponse 
            {
                Version = "1.0",
                Response = new ResponseBody()
            };

            response.Response.OutputSpeech = new PlainTextOutputSpeech() { Text = msg };

            return response;
        }

        private string MakeResponse(IntentRequest ir)
        {
            string msg;

            switch (ir.Intent.Name) 
            {
                case "Hello Alexa From CSharp":
                    msg = messages[new Random().Next(3)];
                    break;

                default:
                    msg = "?????????";
                    break;
            }

            return msg;
        }
    }
}
