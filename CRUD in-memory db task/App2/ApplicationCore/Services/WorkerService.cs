using ApplicationCore.Entities.Interfaces;
using ApplicationCore.Entities.Main;
using ApplicationCore.Interfaces.Base;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class WorkerService : IWorkerService
    {
        private readonly IEFRepository<Worker> WorkerRepository;
        private readonly IEFRepository<Profile> ProfileRepository;

        public WorkerService(IEFRepository<Worker> workerRepository, IEFRepository<Profile> profileRepository)
        {
            WorkerRepository = workerRepository;
            ProfileRepository = profileRepository;
        }

        public async Task UpdateAsync(Worker worker)
        {
            var currentWorker = await WorkerRepository.FindAsync(worker.Id);
            currentWorker.Position = worker.Position;
            currentWorker.Subdivision = worker.Subdivision;
            currentWorker.Salary = worker.Salary;
            await WorkerRepository.UpdateAsync(currentWorker);

            var currentProfile = await ProfileRepository.FindAsync(worker.Profile.Id);
            currentProfile.Fullname = worker.Profile.Fullname;
            currentProfile.Date = worker.Profile.Date;
            currentProfile.Email = worker.Profile.Email;
            currentProfile.Phone = worker.Profile.Phone;
            await ProfileRepository.UpdateAsync(currentProfile);
        }
    }
}