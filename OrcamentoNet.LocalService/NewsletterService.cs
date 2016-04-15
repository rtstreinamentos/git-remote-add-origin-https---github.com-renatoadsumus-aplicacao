using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrcamentoNet.Entity;
using OrcamentoNet.ILocalService;
using OrcamentoNet.Common;
using PerceptiveMCAPI;
using PerceptiveMCAPI.Types;
using PerceptiveMCAPI.Methods;

namespace OrcamentoNet.LocalService
{
    public class NewsletterService : INewsletterService
    {
        listBatchSubscribeInput input = new listBatchSubscribeInput();

        public NewsletterService() {
            // any directive overrides
            input.api_Validate = true;
            input.api_AccessType = EnumValues.AccessType.Serial;
            input.api_OutputType = EnumValues.OutputType.JSON;
            // method parameters
            input.parms.apikey = "5bd4b073902ccb6e5a93a7c4f75206bd-us2";
            input.parms.id = "4c85bff9bd";
            input.parms.double_optin = true;
            input.parms.update_existing = true;
        }

        public NewsletterService(listBatchSubscribeInput input) {
            this.input = input;
        }

        public void AssinarLista(string nome, string email) {
            try
            {
                List<Dictionary<string, object>> batch = new List<Dictionary<string, object>>();
                Dictionary<string, object> entry = new Dictionary<string, object>();
                entry.Add("EMAIL", email);
                entry.Add("FNAME", nome);
                batch.Add(entry);
                input.parms.batch = batch;
                // execution
                listBatchSubscribe cmd = new listBatchSubscribe(input);
                listBatchSubscribeOutput output = cmd.Execute();
                // output, format with user control
                if (output.api_ErrorMessages.Count > 0)
                {
                    string mensagensDeErro = String.Empty;
                    foreach (Api_Error mensagem in output.api_ErrorMessages)
                    {
                        if (!String.IsNullOrEmpty(mensagensDeErro)) mensagensDeErro = mensagensDeErro + ", ";
                        mensagensDeErro = mensagensDeErro + mensagem;
                    }

                    string mensagensDoValidator = String.Empty;
                    foreach (Api_ValidatorMessage mensagem in output.api_ValidatorMessages)
                    {
                        if (!String.IsNullOrEmpty(mensagensDoValidator)) mensagensDoValidator = mensagensDoValidator + ", ";
                        mensagensDoValidator = mensagensDoValidator + mensagem;
                    }

                    Email.NotificarAdministracao("Erro na assinatura da lista", "api_Request: " + output.api_Request + "<br />api_Response: " + output.api_Response + "<br />api_ErrorMessages: " + mensagensDeErro + "<br />api_ValidatorMessages: " + mensagensDoValidator);
                }
            }
            catch (Exception ex)
            {
                Log.GravarLog(ex.Message);
            }
        }
    }
}
