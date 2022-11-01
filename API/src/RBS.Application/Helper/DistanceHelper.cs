namespace RBS.Application.Helper
{
    public static class DistanceHelper
    {
        public static double DistanceTo(string lat1, string lon1, string lat2, string lon2, char unit = 'K')
        {
            double rlat1 = Math.PI * double.Parse(lat1) / 180;
            double rlat2 = Math.PI * double.Parse(lat2) / 180;
            double theta = double.Parse(lon1) - double.Parse(lon2);
            double rtheta = Math.PI * theta / 180;
            double dist =
                Math.Sin(rlat1) * Math.Sin(rlat2) + Math.Cos(rlat1) *
                Math.Cos(rlat2) * Math.Cos(rtheta);
            dist = Math.Acos(dist);
            dist = dist * 180 / Math.PI;
            dist = dist * 60 * 1.1515;

            return unit switch
            {
                'K' => dist * 1.609344,
                'N' => dist * 0.8684,
                'M' => dist,
                _ => dist,
            };
        }
    }
}
