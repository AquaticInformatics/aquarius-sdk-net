using Aquarius.TimeSeries.Client;
using NUnit.Framework;

#if AUTOFIXTURE4
using AutoFixture;
#else
using Ploeh.AutoFixture;
#endif

namespace Aquarius.Client.UnitTests.TimeSeries.Client
{
    [TestFixture]
    public abstract class ConnectionTestBase<TConnection, TAuthenticator> 
        where TConnection : IConnection
        where TAuthenticator : IAuthenticator
    {
        protected IFixture _fixture;
        protected TConnection _connection;
        protected int _connectionRemovalCount;
        protected IAuthenticator _mockAuthenticator;

        [SetUp]
        public void BeforeEach()
        {
            _fixture = new Fixture();
            _connectionRemovalCount = 0;
            _mockAuthenticator = CreateMockAuthenticator();
            _connection = CreateMockConnection();
        }

        protected abstract IAuthenticator CreateMockAuthenticator();
        protected abstract TConnection CreateMockConnection();

        protected void RemoveConnection(IConnection connection) => ++_connectionRemovalCount;
        
        protected abstract void AssertExpectedConnectionCount(int expectedCount);
        protected abstract void AssertExpectedSessionCreateCount(int expectedCount);
        protected abstract void AssertExpectedSessionDeleteCount(int expectedCount);
        protected abstract void AssertExpectedConnectionRemovalCount(int expectedCount);

        [Test]
        public void NewlyConstructedConnection_TracksOneConnection()
        {
            AssertExpectedConnectionCount(1);
            AssertExpectedSessionCreateCount(1);
            AssertExpectedSessionDeleteCount(0);
            AssertExpectedConnectionRemovalCount(0);
        }
        
        [Test]
        public void IncrementConnectionCount_IncrementsConnectionCount()
        {
            _connection.IncrementConnectionCount();

            AssertExpectedConnectionCount(2);
            AssertExpectedSessionCreateCount(1);
            AssertExpectedSessionDeleteCount(0);
            AssertExpectedConnectionRemovalCount(0);
        }
        
        [Test]
        public void Close_WithSingleConnectCount_DeletesSession()
        {
            _connection.Close();

            AssertExpectedSessionCreateCount(1);
            AssertExpectedSessionDeleteCount(1);
            AssertExpectedConnectionRemovalCount(1);
        }
        
        [Test]
        public void Close_WithMoreThanOneConnection_DoesNotDeleteSession()
        {
            _connection.IncrementConnectionCount();

            _connection.Close();

            AssertExpectedSessionCreateCount(1);
            AssertExpectedSessionDeleteCount(0);
            AssertExpectedConnectionRemovalCount(0);
        }
    }
}