using BicycleRESTforCD.Models;

namespace BicycleRESTforCD.Repositories
{
    public class BicycleRepository
    {
        private readonly List<Bicycle> _bicycles = new();
        private int nextId = 1;

        public BicycleRepository()
        {
            _bicycles.Add(new Bicycle { Id = nextId++, Color = "Red" });
            _bicycles.Add(new Bicycle { Id = nextId++, Color = "Blue" });
            _bicycles.Add(new Bicycle { Id = nextId++, Color = "Green" });
        }

        public List<Bicycle> GetAll()
        {
            return new List<Bicycle>(_bicycles);
        }

        public Bicycle? GetById(int id)
        {
            return _bicycles.FirstOrDefault(b => b.Id == id);
        }

        public Bicycle Add(Bicycle bicycle)
        {
            bicycle.Validate();
            bicycle.Id = nextId++;
            _bicycles.Add(bicycle);
            return bicycle;
        }

        public Bicycle? Delete(int id)
        {
            Bicycle? bicycle = _bicycles.FirstOrDefault(b => b.Id == id);
            if (bicycle == null)
            {
                return null;
            }
            _bicycles.Remove(bicycle);
            return bicycle;
        }
    }
}
