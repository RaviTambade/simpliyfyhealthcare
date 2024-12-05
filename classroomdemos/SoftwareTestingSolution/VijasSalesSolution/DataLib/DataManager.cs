namespace DataLib
{
    public class DataManager
    {
        private readonly IRepository _repository;

        public DataManager(IRepository repository)
        {
            _repository = repository;
        }

        public string GetDataFromRepository()
        {
            return _repository.GetData();
        }
    }
}