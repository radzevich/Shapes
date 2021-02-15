namespace Shapes.Shapes
{
    public class VehicleDocument : IDocument
    {
        public string Vin { get; set; }
        
        public string GenerateId()
        {
            return Vin;
        }
    }
}