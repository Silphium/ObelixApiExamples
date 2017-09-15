import Menhir


from Menhir import MenhirRack
from PIL import Image

def main():

    AssetMangmentDataBaseIP = "10.64.12.11"
    ObelixServerIpList = ["10.64.12.157"]


    TestMenhir = MenhirRack(AssetMangmentDataBaseIP, ObelixServerIpList)

    TestMenhir.LoadObelixServers()
    TestMenhir.ConnectAll()
    

    
      
    


if  __name__ =='__main__':main()

