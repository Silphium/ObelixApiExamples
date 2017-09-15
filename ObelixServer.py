import MySQLdb 
import ObelixTestSpace
import sys

from ObelixTestSpace import ObelixTestSpace

class ObelixServer(object):
    """description of class"""

    def __init__(self, asterixIp, obelixIp):
        self.AsterixLocation = asterixIp
        self.IpAddress = obelixIp


    def LoadTopography(self):
        ''' Loads Topography from Asterix
        '''
        try:
            db = MySQLdb.connect(
                self.AsterixLocation,
                'scripterIn', 
                'scripter',
                'asterixtestnetwork')
            cursor = db.cursor()
            SelectSql = "SELECT ServerID, ServerName, SlotCount FROM obelixservertable WHERE ServerIPAddress='" + self.IpAddress + "'"
            cursor.execute(SelectSql)
            ServerDetails = cursor.fetchall()
            for Field in ServerDetails:
                self.PrimaryKey = Field[0]
                self.ServerName = Field[1]
                self.SlotCount = Field[2]
            print(self.ServerName)
            db.close()
            self.TestDeviceList = [] 
            for Slot in range(1, self.SlotCount):
                TestSpace = ObelixTestSpace(self.PrimaryKey, self.IpAddress, Slot) 
                self.TestDeviceList.append(TestSpace)
        except MySQLdb.Error as err:
            print(err)

        

         
        

    

