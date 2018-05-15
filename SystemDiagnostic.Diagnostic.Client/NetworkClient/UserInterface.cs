using System;
using System.Net;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRClient.Entities;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRClient.Interfaces;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.Entities;

namespace SystemDiagnostic.Diagnostic.Client.NetworkClient
{
    public class UserInterface : IUserInterface
    {
        public UserInterface(){}
        private object consoleLocker = new object();
        public ClientCommandRequest InputCommand(UIOutputModel outputModel)
        {
            throw new NotImplementedException();
        }

        public ClientLoginModel InputLogin(UIOutputModel outputModel)
        {
            string login;
            string password;
            bool ErrorLogin = false, ErrorPassword = false;
            lock(consoleLocker){
                do{
                    Console.WriteLine(outputModel.Title);
                    Console.WriteLine(outputModel.OtherInformation);
                    Console.WriteLine("Please Input Login:");
                    login = Console.ReadLine();
                    Console.WriteLine("Please Input Password");
                    password = Console.ReadLine();
                    ErrorLogin = string.IsNullOrEmpty(login);
                    ErrorPassword = string.IsNullOrWhiteSpace(password);
                }while(ErrorLogin || ErrorPassword);
            }
            return new ClientLoginModel{
                Login = login,
                Password = password
            };
        }

        public RunInputModel InputRunProperties(UIOutputModel outputModel)
        {
            bool ErrorIp = false, ErrorPort = false;
            IPAddress ip;
            int port;
            lock(consoleLocker){
                do{
                    Console.WriteLine(outputModel.Title);
                    Console.WriteLine(outputModel.OtherInformation);
                    Console.WriteLine("Input ip address:");
                    string ipstr =  Console.ReadLine();
                    Console.WriteLine("Input port:");
                    string portstr = Console.ReadLine();                
                    ErrorIp = !IPAddress.TryParse(ipstr,out ip);                
                    ErrorPort = !int.TryParse(portstr,out port); 
                }while(ErrorIp || ErrorPort);
            }
            return new RunInputModel{
                IPAddress = ip,
                Port = port
            };
        }

        public void OutputMessage(UIOutputModel outputModel)
        {
            lock(consoleLocker){
                Console.WriteLine(outputModel.Title);
                Console.WriteLine(outputModel.OtherInformation);
            }
        }

        public void SetClientMediator(IClientMediator clientMediator)
        {
            throw new NotImplementedException();
        }
    }
}
