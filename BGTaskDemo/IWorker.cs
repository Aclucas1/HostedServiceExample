namespace BGTaskDemo
{
    interface IWorker
    {
        void DoWork(string pipeline);
        bool ShouldRun();
    }
}