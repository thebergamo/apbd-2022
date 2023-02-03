namespace DoctorsAPI.Models.DTO;

public interface IResponseDTO<TModel, TResponse>
{
    public static abstract TResponse FromModel(TModel model);

}