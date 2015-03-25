// --------------------------------------------------------------------------------------------------------------------
// <copyright company="SomeCompany" file="GasStationInfo.cs">
//   Copyright 2015
// </copyright>
// <summary>
//   Gas Station classes
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GasStation
{
    using System.Collections.Generic;

    /// <summary>
    /// The precision.
    /// </summary>
    public class Precision
    {
        public string name { get; set; }
        public List<string> types { get; set; }
        public int value { get; set; }
    }

    /// <summary>
    /// The e 85.
    /// </summary>
    public class E85
    {
        public int total { get; set; }
    }

    /// <summary>
    /// The stations.
    /// </summary>
    public class Stations
    {
        public int total { get; set; }
    }

    /// <summary>
    /// The elec.
    /// </summary>
    public class ELEC
    {
        public int total { get; set; }
        public Stations stations { get; set; }
    }

    /// <summary>
    /// The hy.
    /// </summary>
    public class HY
    {
        public int total { get; set; }
    }

    /// <summary>
    /// The lng.
    /// </summary>
    public class LNG
    {
        public int total { get; set; }
    }

    /// <summary>
    /// The bd.
    /// </summary>
    public class BD
    {
        public int total { get; set; }
    }

    /// <summary>
    /// The cng.
    /// </summary>
    public class CNG
    {
        public int total { get; set; }
    }

    /// <summary>
    /// The lpg.
    /// </summary>
    public class LPG
    {
        public int total { get; set; }
    }

    /// <summary>
    /// The fuels.
    /// </summary>
    public class Fuels
    {
        public E85 E85 { get; set; }
        public ELEC ELEC { get; set; }
        public HY HY { get; set; }
        public LNG LNG { get; set; }
        public BD BD { get; set; }
        public CNG CNG { get; set; }
        public LPG LPG { get; set; }
    }

    /// <summary>
    /// The station counts.
    /// </summary>
    public class StationCounts
    {
        public int total { get; set; }
        public Fuels fuels { get; set; }
    }

    /// <summary>
    /// The ev network ids.
    /// </summary>
    public class EvNetworkIds
    {
        public List<string> posts { get; set; }
    }

    /// <summary>
    /// The fuel station.
    /// </summary>
    public class FuelStation
    {
        public string access_days_time { get; set; }
        public object cards_accepted { get; set; }
        public string date_last_confirmed { get; set; }
        public object expected_date { get; set; }
        public string fuel_type_code { get; set; }
        public int id { get; set; }
        public string groups_with_access_code { get; set; }
        public object open_date { get; set; }
        public object owner_type_code { get; set; }
        public string status_code { get; set; }
        public string station_name { get; set; }
        public string station_phone { get; set; }
        public string updated_at { get; set; }
        public string geocode_status { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string city { get; set; }
        public object intersection_directions { get; set; }
        public object plus4 { get; set; }
        public string state { get; set; }
        public string street_address { get; set; }
        public string zip { get; set; }
        public object bd_blends { get; set; }
        public object e85_blender_pump { get; set; }
        public List<string> ev_connector_types { get; set; }
        public object ev_dc_fast_num { get; set; }
        public int? ev_level1_evse_num { get; set; }
        public int ev_level2_evse_num { get; set; }
        public string ev_network { get; set; }
        public string ev_network_web { get; set; }
        public object ev_other_evse { get; set; }
        public object hy_status_link { get; set; }
        public object lpg_primary { get; set; }
        public object ng_fill_type_code { get; set; }
        public object ng_psi { get; set; }
        public object ng_vehicle_class { get; set; }
        public EvNetworkIds ev_network_ids { get; set; }
        public double distance { get; set; }
    }

    /// <summary>
    /// The root object.
    /// </summary>
    public class RootObject
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public Precision precision { get; set; }
        public string station_locator_url { get; set; }
        public int total_results { get; set; }
        public StationCounts station_counts { get; set; }
        public int offset { get; set; }
        public List<FuelStation> fuel_stations { get; set; }
    }

    /// <summary>
    /// The fuel station address.
    /// </summary>
    public class FuelStationAddress
    {
        public AltFuelStation alt_fuel_station { get; set; }
    }

    /// <summary>
    /// The alt fuel station.
    /// </summary>
    public class AltFuelStation
    {
        public string access_days_time { get; set; }
        public object cards_accepted { get; set; }
        public string date_last_confirmed { get; set; }
        public object expected_date { get; set; }
        public string fuel_type_code { get; set; }
        public int id { get; set; }
        public string groups_with_access_code { get; set; }
        public object open_date { get; set; }
        public object owner_type_code { get; set; }
        public string status_code { get; set; }
        public string station_name { get; set; }
        public string station_phone { get; set; }
        public string updated_at { get; set; }
        public string geocode_status { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string city { get; set; }
        public object intersection_directions { get; set; }
        public object plus4 { get; set; }
        public string state { get; set; }
        public string street_address { get; set; }
        public string zip { get; set; }
        public object bd_blends { get; set; }
        public object e85_blender_pump { get; set; }
        public List<string> ev_connector_types { get; set; }
        public object ev_dc_fast_num { get; set; }
        public object ev_level1_evse_num { get; set; }
        public int ev_level2_evse_num { get; set; }
        public string ev_network { get; set; }
        public string ev_network_web { get; set; }
        public object ev_other_evse { get; set; }
        public object hy_status_link { get; set; }
        public object lpg_primary { get; set; }
        public object ng_fill_type_code { get; set; }
        public object ng_psi { get; set; }
        public object ng_vehicle_class { get; set; }
        public EvNetworkIds ev_network_ids { get; set; }
    }
}
