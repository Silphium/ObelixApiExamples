import requests

class ObelixTestSpace(object):
    """description of class"""

    def __init__(self, serverKey, serverIp, slot):
        self.ServerKey = serverKey
        self.ServerIp = serverIp
        self.Slot = slot


    def Connect(self, userName, userMachine):
        ''' Connects to the Obelix Server to open this test space
        Arguments:
            userName - the name of the test space user
            userMachine - the name of the machine the user is using
        '''
        ConnectUri = self.CreateConnectUri(userName, userMachine)
  
        try:
            r = requests.get(ConnectUri)
           
        except Exception as error: 
            print error

    def Disconnect(self):
        ''' Disconects from a remote session 
        '''
        url = self.CreateDisconnectUri()
        try:
            r = requests.get(url)
        except Exception as error: 
            print error

    def GetScreenShot(self):
        ''' Returns a jpeg screenshot from the remote test device
        '''
        url = ("http://%s/TestSpace/%d/ScreenShot/"%(self.ServerIp,self.Slot))
        try:
            r = requests.get(url)
            return r.content
        except Exception as error: 
            print error

    def SendCommand(self, commandName):
        url = ("http://%s/TestSpace/%d/Handset/Send?cmd=%s/"%(self.ServerIp,self.Slot,commandName))
        try:
            r = requests.get(url)
        except Exception as error: 
            print error


    def CreateConnectUri(self, userName, userMachine):
        ''' Creates the Uri used to form the test space connection request
        Arguments:
            userName - the name of the test space user
            userMachine - the name of the machine the user is using
        '''
        self.UriSafeName = userName.replace(' ', '+')
        UriSafeMachine = userMachine.replace(' ', '+')

        ConnectUrl = ("http://%s/TestSpace/%d/Connect/?user=%s;machine=%s"%(self.ServerIp, self.Slot, self.UriSafeName, UriSafeMachine))
        return ConnectUrl


    def CreateDisconnectUri(self):
        ''' Creates the disconnect uri used to terminate a test space session
        '''
        url = ("http://%s/TestSpace/%d/Disconnect/?user=%s;"%(self.ServerIp, self.Slot, self.UriSafeName))
        return url


        
    

