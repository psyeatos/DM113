using APIMinima.model;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
  public DbSet<Message> Messages { get; set; }
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    base.OnConfiguring(optionsBuilder);
    optionsBuilder.UseSqlServer(
        "Server=localhost\\SQLEXPRESS;"
        + "User id=dm113;"
        + "Password=dm113;"
        + "Database=DM113;"
        + "Trusted_Connection=True;"
        + "encrypt=false");
  }
}

public class AppDbContext
{

  public object Message { get; internal set; }

  public void DeleteMessage(string personId)
  {
    var existingMessage = Message.ToString();
    if (existingMessage != null)
    {
      /* Message.Remove(existingMessage); */
      Console.WriteLine($"Mensagem com ID {personId} excluída com sucesso.");
    }
    else
    {
      Console.WriteLine($"Mensagem com ID {personId} não encontrada.");
    }
  }
  public void UpdateMessage(string personId, Message updatedMessage)
  {
    var existingMessage = Message.ToString();
    if (existingMessage != null)
    {
      /* existingMessage.Content = updatedMessage.Content;
      existingMessage.IsUrgent = updatedMessage.IsUrgent; */
      Console.WriteLine($"Mensagem com ID {personId} atualizada com sucesso.");
    }
    else
    {
      // Se a mensagem não existir, imprimir uma mensagem de erro
      Console.WriteLine($"Mensagem com ID {personId} não encontrada.");
    }
  }

  public void SaveChanges()
  {
    throw new NotImplementedException();
  }
}