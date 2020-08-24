using System.Collections.Generic;
namespace GasStation
{
public class FieldAliases    {
        public string OBJECTID { get; set; } 
        public string ADRESSE { get; set; } 
    }

    public class SpatialReference    {
        public int wkid { get; set; } 
        public int latestWkid { get; set; } 
    }

    public class Field    {
        public string name { get; set; } 
        public string type { get; set; } 
        public string alias { get; set; } 
        public int? length { get; set; } 
    }

    public class Attributes    {
        public int OBJECTID { get; set; } 
        public string ADRESSE { get; set; } 
    }

    public class Geometry    {
        public double x { get; set; } 
        public double y { get; set; } 
    }

    public class Feature    {
        public Attributes attributes { get; set; } 
        public Geometry geometry { get; set; } 
    }

    public class GasStationResponse    {
        public string displayFieldName { get; set; } 
        public FieldAliases fieldAliases { get; set; } 
        public string geometryType { get; set; } 
        public SpatialReference spatialReference { get; set; } 
        public List<Field> fields { get; set; } 
        public List<Feature> features { get; set; } 
    }

}