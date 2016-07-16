using System;
using RacingMachinez.Contracts.Plugins;
using RacingMachinez.Contracts;

namespace RacingMachinez.Plugins.Clusters.Auduino
{
    public sealed class AuduinoCluster : ICluster
    {
        private bool _isDisposed = false;

        private ComCommunicator _writer;

        public event EventHandler<EventArgs> ConnectionLost;

        public bool IsConnected { get; private set; } = false;

        public bool Connect(ClusterConfiguration configuration)
        {
            if (!IsConnected)
            {
                try
                {
                    _writer?.Dispose();
                    _writer = new ComCommunicator(configuration);
                    IsConnected = true;
                }
                catch (Exception)
                {
                    IsConnected = false;
                }
            }

            return IsConnected;
        }

        public void UpdateGameData(GameData gameData)
        {
            PerformClusterOperation(() => _writer.Send(gameData));
        }

        public void SetClusterState(ClusterState state)
        {
            PerformClusterOperation(() => _writer.SetState(state));
        }

        public ClusterState GetClusterState()
        {
            return PerformClusterOperation(() => _writer.GetState(), ClusterState.Unknown);
        }

        public void Ping()
        {
            GetClusterState();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (_isDisposed)
            {
                return;
            }

            if (disposing)
            {
                _writer?.Dispose();
                _writer = null;
            }

           _isDisposed = true;
        }

        private void PerformClusterOperation(Action operation)
        {
            PerformClusterOperation(() =>
            {
                operation();
                return true;
            }, false);
        }

        private T PerformClusterOperation<T>(Func<T> operation, T defaultResult)
        {
            if (IsConnected)
            {
                try
                {
                    return operation();
                }
                catch (Exception)
                {
                    IsConnected = false;
                    ConnectionLost?.Invoke(this, EventArgs.Empty);
                }
            }

            return defaultResult;
        }
    }
}
