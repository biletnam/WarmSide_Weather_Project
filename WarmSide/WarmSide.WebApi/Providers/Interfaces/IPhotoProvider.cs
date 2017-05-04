namespace WarmSide.WebApi.Providers.Interfaces
{
    interface IPhotoProvider
    {
        byte[] GetPlacePhoto(string cityName);
    }
}
