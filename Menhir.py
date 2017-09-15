import ObelixServer
import ObelixTestSpace

from ObelixServer import ObelixServer
from ObelixTestSpace import ObelixTestSpace

class MenhirRack(object):
    """Represents a complete Obelix Server Rack"""

    def __init__(self, databaseIp, obelixServerIpList):
        '''Construtor

        Arguments:
        databseIp -- The location of the AsterixTestNetwork DB
        obelixServerIpList -- list of Ip Address of the Rack's Obelix Servers
        '''
        self.AsterixLocation = databaseIp
        self.CreateObelixServers(obelixServerIpList)

    def CreateObelixServers(self, obelixServerIpList):
        '''Creates the list of Obelix Servers used by this rack

        Arguments:
        obelixServerIpList -- List of the IP Addresses of the Servers
        '''  
        self.ServerList = []
        for IpAddress in obelixServerIpList:
            RackServer = ObelixServer(self.AsterixLocation, IpAddress) 
            self.ServerList.append(RackServer)

    def LoadObelixServers(self):
        ''' Loops through the server list and loads their topography
        '''
        for RackServer in self.ServerList:
            RackServer.LoadTopography()

    def ConnectAll(self):
        TestSpace = self.ServerList[0].TestDeviceList[0]
        TestSpace.Connect("Keith Douglas", "Beautiful Laptop")

    def GetScreenShotList(self):
       return self.ServerList[0].TestDeviceList[0].GetScreenShot()
        
            
            
    