using JsonClasses;
using Newtonsoft.Json;

class DeviceAuthorisation {
    
    public static bool IsTourOnline() {
        if (!File.Exists(Paths.JsonFileBaseServer("tour_data"))) {
            return false;
        }
        
        TourData tourData = JsonConvert.DeserializeObject<TourData>(File.ReadAllText(File.ReadAllText(Paths.JsonFileBaseServer("tour_data"))));

        return tourData.is_online;

    }
    
    public static bool IsDeviceAuthorised(string id) {
        if (!File.Exists(Paths.JsonFileBaseServer("device_ids"))) {
            return false;
        }

        DeviceIdsPacket devicePacket = JsonConvert.DeserializeObject<DeviceIdsPacket>(File.ReadAllText(Paths.JsonFileBaseServer("device_ids")));   

        if (devicePacket.authorised_device_ids.Contains(id))
            return true;

        return false;
    }
}