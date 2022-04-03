namespace WebApplicationlabb.DAL
{

    public class UnitOfWork : IDisposable
    {
        private readonly DataContext _context;

        private IUserRepository _userRepository;

        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_context);
                }

                return _userRepository;
            }
        }

        private ICourseRepository _courseRepository;

        public ICourseRepository CourseRepository
        {
            get
            {
                if (_courseRepository == null)
                {
                    _courseRepository = new CourseRepository(_context);
                }

                return _courseRepository;
            }
        }

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
            //_userRepository.Dispose();
            //_courseRepository.Dispose();

        }
    }
}
