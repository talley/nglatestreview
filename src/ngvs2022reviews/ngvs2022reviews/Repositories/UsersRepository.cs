namespace ngvs2022reviews.Repositories
{
    public class UsersRepository : IRepository<Users>
    {
        private readonly NorthwindContext db = new NorthwindContext();

        public int Delete(Users model)
        {
            int result = 0;
            try
            {
                db.Entry(model).State =EntityState.Deleted;
                result=db.SaveChanges();
            }
            catch (Exception ex) when (ex != null)
            {
                throw;
            }
            return result;
        }

        public async Task<int> DeleteAsync(Users model)
        {
            int result = 0;
            try
            {
                db.Entry(model).State = EntityState.Deleted;
                result =await db.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (Exception ex) when (ex != null)
            {
                throw;
            }
            return result;
        }

        public List<Users> GetAll()
        {
            return db.Users.ToList();
        }

        public async Task<List<Users>> GetAllAsync()
        {
            return await db.Users.ToListAsync().ConfigureAwait(false);
        }

        public int SaveOrUpdate(Users model)
        {
            int result = 0;
            try
            {
                if (model.id == Guid.Empty)
                {
                    model.id = Guid.NewGuid();
                    db.Entry(model).State = EntityState.Added;
                    result = db.SaveChanges();
                }
                else
                {
                    var users=GetAll();
                    var user = users.SingleOrDefault(x => x.id == model.id);
                    if (user == null)
                    {
                        throw new ArgumentNullException($"User with id:{model.id} does not exist");
                    }
                    else
                    {
                        user.updatedby = model.updatedby ?? Environment.MachineName;
                        user.updatedat = DateTime.Now;
                        user.password = model.password;
                        user.email = model.email;
                        user.createdat = model.createdat;
                        user.createdby = model.createdby;

                        db.Entry(user).State = EntityState.Modified;
                        result = db.SaveChanges();
                    }

                }
            }
            catch (Exception ex) when(ex!=null)
            {

                throw;
            }
            return result;
        }

        public async Task<int> SaveOrUpdateAsync(Users model)
        {
            int result = 0;
            try
            {
                if (model.id == Guid.Empty)
                {
                    model.id = Guid.NewGuid();
                    db.Entry(model).State = EntityState.Added;
                    result =await db.SaveChangesAsync().ConfigureAwait(false);
                }
                else
                {
                    var users = GetAll();
                    var user = users.SingleOrDefault(x => x.id == model.id);
                    if (user == null)
                    {
                        throw new ArgumentNullException($"User with id:{model.id} does not exist");
                    }
                    else
                    {
                        user.updatedby = model.updatedby ?? Environment.MachineName;
                        user.updatedat = DateTime.Now;
                        user.password = model.password;
                        user.email = model.email;
                        user.createdat = model.createdat;
                        user.createdby = model.createdby;

                        db.Entry(user).State = EntityState.Modified;
                        result = await db.SaveChangesAsync().ConfigureAwait(false);
                    }

                }
            }
            catch (Exception ex) when (ex != null)
            {

                throw;
            }
            return result;
        }
    }
}