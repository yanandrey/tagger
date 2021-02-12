namespace tagger.Service
{
    public class DatabaseServices : IDatabaseServices
    {
        public string VideosCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
    
    public interface IDatabaseServices
    {
        string VideosCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}