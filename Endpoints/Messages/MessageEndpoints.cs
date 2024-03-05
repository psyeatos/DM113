public class MessageEndpoints
{
  private readonly AppDbContext _dbContext;

  public MessageEndpoints(AppDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  public RouteGroupBuilder builder;
  public MessageEndpoints(RouteGroupBuilder b, AppDbContext dbContext)
  {
    builder = b;
    _dbContext = dbContext;
    SetupEndpoints();
  }
  void SetupEndpoints()
  {

    builder.MapGet("/", () => "Get");

    builder.MapGet("/{personId}", (string personId) => $"Get by {personId}");

    builder.MapGet("/messages", (string date) => $"Dia {date}");

    builder.MapMethods(MessageGetAll.Route, MessageGetAll.Methods, MessageGetAll.Handler);

    builder.MapPost("/", (Message message, HttpResponse response) =>
    {
      response.Headers.Add("token", "12345");
      return message;
    });

    builder.MapPut("/{personId}", (string personId, Message message, HttpResponse response) =>
        {
          try
          {
            _dbContext.UpdateMessage(personId, message);
            return $"Mensagem com ID {personId} atualizada com sucesso";
          }
          catch (Exception ex)
          {
            return $"Ocorreu um erro ao atualizar a mensagem: {ex.Message}";
          }
        });

    builder.MapDelete("/{personId}", (string personId, HttpResponse response) =>
    {
      try
      {
        var existingMessage = _dbContext.Message.ToString();
        if (existingMessage == null)
        {
          return $"Mensagem com ID {personId} não encontrada.";
        }
        /* _dbContext.Messages.Remove(existingMessage); */
        _dbContext.SaveChanges();

        return $"Mensagem com ID {personId} excluída com sucesso";
      }
      catch (Exception ex)
      {
        return $"Ocorreu um erro ao excluir a mensagem: {ex.Message}";
      }
    });
  }
}