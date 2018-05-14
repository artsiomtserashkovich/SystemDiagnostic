using System;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRClient.Entities;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRClient.Interfaces;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.Entities;

namespace SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRClient
{
    public class Client : IClient
    {
        private ClientLoginModel ClientLogin { get; set; }
        private IScheduleCommandManager _scheduleCommandManager;
        private ICRClient _crClient;
        private IClientCommandHandler _clientCommandHandler;
        private IClientResponseHandler _clientResponseHandler;
        private IUserInterface _userInterface;

        public bool IsRun { get; private set; }

        public Client(IClientCommandHandler clientCommandHandler,
            IClientResponseHandler clientResponseHandler,
            IScheduleCommandManager scheduleCommandManager,
            IUserInterface userInferface)
        {
            _clientCommandHandler = clientCommandHandler;
            _clientCommandHandler.SetClientMediator(this);
            _clientResponseHandler = clientResponseHandler;
            _clientResponseHandler.SetClientMediator(this);
            _scheduleCommandManager = scheduleCommandManager;
            _scheduleCommandManager.SetClientMediator(this);
            _userInterface = userInferface;
            _userInterface.SetClientMediator(this);
            _crClient = new CRClient(this);
        }
        public void Dispose()
        {
            _crClient.Dispose();
        }

        public void HandleResponse(ServerResponseDTO serverResponse)
        {
            try
            {
                _clientResponseHandler.HandleServerResponse(serverResponse);
            }
            catch (Exception exception)
            {
                throw new SystemDiagnosticClientException(exception, "Error with handle response.");
            }
        }

        public void OutputUIMessage(UIOutputModel messageModel)
        {
            _userInterface.OutputMessage(messageModel);
        }

        public ClientCommandDTO ProducingClientCommand(ClientCommandRequest ClientCommandRequest)
        {
            try
            {
                if (ClientLogin == null)
                {
                    ClientLogin = _userInterface.InputLogin(new UIOutputModel { });
                }
                return _clientCommandHandler.HandleClientCommandRequest(ClientCommandRequest, ClientLogin);
            }
            catch (Exception exception)
            {
                throw new SystemDiagnosticClientException(exception, "");
            }
        }

        public ClientCommandRequest UIInputCommand(UIOutputModel inputModel)
        {
            try
            {
                return _userInterface.InputCommand(inputModel);
            }
            catch (Exception exception)
            {
                throw new SystemDiagnosticClientException(exception, "Error at user interface.");
            }
        }

        private void Run()
        {
            try
            {
                RunInputModel runInputModel = _userInterface.InputRunProperties(new UIOutputModel { });
                _crClient.Run(runInputModel.IPAddress, runInputModel.Port);
                IsRun = true;
            }
            catch (Exception exception)
            {
                throw new SystemDiagnosticClientException(exception, "Error while starting client.");
            }
        }

        public void SendClientCommand(ClientCommandDTO clientCommand)
        {
            if (!IsRun)
                Run();
            else
                _crClient.RecieveUserCommand(clientCommand);
        }

        public void Start()
        {
            if(!IsRun)
                Run();
            else 
                throw new SystemDiagnosticClientException("Client already start");
        }
    }
}
