using System.Collections.Generic;
using System.Threading.Tasks;
using IkeMtz.NRSRx.Core.Models;
using IkeMtz.NRSRx.Events;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace IkeMtz.NRSRx.Core.Unigration.WebApi
{
  public class PublisherIntegrationTester<Entity, MessageType> : PublisherIntegrationTester<Entity>
       where Entity : IIdentifiable
  {
    public Mock<IPublisher<Entity, CreateEvent, MessageType>> CreatePublisher { get; }
    public Mock<IPublisher<Entity, CreatedEvent, MessageType>> CreatedPublisher { get; }
    public Mock<IPublisher<Entity, UpdatedEvent, MessageType>> UpdatedPublisher { get; }
    public Mock<IPublisher<Entity, DeletedEvent, MessageType>> DeletedPublisher { get; }

    public PublisherIntegrationTester()
    {
      CreatePublisher = new Mock<IPublisher<Entity, CreateEvent, MessageType>>();
      CreatedPublisher = new Mock<IPublisher<Entity, CreatedEvent, MessageType>>();
      UpdatedPublisher = new Mock<IPublisher<Entity, UpdatedEvent, MessageType>>();
      DeletedPublisher = new Mock<IPublisher<Entity, DeletedEvent, MessageType>>();

      CreatePublisher
          .Setup(t => t.PublishAsync(Capture.In(CreateList), null))
          .Returns(Task.CompletedTask);
      CreatedPublisher
          .Setup(t => t.PublishAsync(Capture.In(CreatedList), null))
          .Returns(Task.CompletedTask);
      UpdatedPublisher
          .Setup(t => t.PublishAsync(Capture.In(UpdatedList), null))
          .Returns(Task.CompletedTask);
      DeletedPublisher
          .Setup(t => t.PublishAsync(Capture.In(DeletedList), null))
          .Returns(Task.CompletedTask);
    }

    public void RegisterDependencies(IServiceCollection services)
    {
      services.AddSingleton(CreatePublisher.Object);
      services.AddSingleton(CreatedPublisher.Object);
      services.AddSingleton(UpdatedPublisher.Object);
      services.AddSingleton(DeletedPublisher.Object);
    }
  }

  public class PublisherIntegrationTester<Entity, MessageType, IdentityType> : PublisherIntegrationTester<Entity>
      where Entity : IIdentifiable<IdentityType>
  {
    public Mock<IPublisher<Entity, CreateEvent, MessageType, IdentityType>> CreatePublisher { get; }
    public Mock<IPublisher<Entity, CreatedEvent, MessageType, IdentityType>> CreatedPublisher { get; }
    public Mock<IPublisher<Entity, UpdatedEvent, MessageType, IdentityType>> UpdatedPublisher { get; }
    public Mock<IPublisher<Entity, DeletedEvent, MessageType, IdentityType>> DeletedPublisher { get; }

    public PublisherIntegrationTester()
    {
      CreatePublisher = new Mock<IPublisher<Entity, CreateEvent, MessageType, IdentityType>>();
      CreatedPublisher = new Mock<IPublisher<Entity, CreatedEvent, MessageType, IdentityType>>();
      UpdatedPublisher = new Mock<IPublisher<Entity, UpdatedEvent, MessageType, IdentityType>>();
      DeletedPublisher = new Mock<IPublisher<Entity, DeletedEvent, MessageType, IdentityType>>();

      CreatePublisher
          .Setup(t => t.PublishAsync(Capture.In(CreateList), null))
          .Returns(Task.CompletedTask);
      CreatedPublisher
          .Setup(t => t.PublishAsync(Capture.In(CreatedList), null))
          .Returns(Task.CompletedTask);
      UpdatedPublisher
          .Setup(t => t.PublishAsync(Capture.In(UpdatedList), null))
          .Returns(Task.CompletedTask);
      DeletedPublisher
          .Setup(t => t.PublishAsync(Capture.In(DeletedList), null))
          .Returns(Task.CompletedTask);
    }

    public void RegisterDependencies(IServiceCollection services)
    {
      services.AddSingleton(CreatePublisher.Object);
      services.AddSingleton(CreatedPublisher.Object);
      services.AddSingleton(UpdatedPublisher.Object);
      services.AddSingleton(DeletedPublisher.Object);
    }
  }

  public abstract class PublisherIntegrationTester<Entity>
  {
    public List<Entity> CreateList { get; } = new List<Entity>();
    public List<Entity> CreatedList { get; } = new List<Entity>();
    public List<Entity> UpdatedList { get; } = new List<Entity>();
    public List<Entity> DeletedList { get; } = new List<Entity>();
  }
}

