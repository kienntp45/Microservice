using Iot.Class.Data.Reponsitoris.Interface;
using Iot.Class.Domain.ReadModels;
using Iot.Core.Data.Relational.Repositories.Implements;
using Iot.Core.Data.Relational.Repositories.Interfaces;
using Iot.Core.MultiTenancy.Abstraction.Providers.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Iot.Class.Data.Reponsitoris.Implemets;

public class ClassRepository:Repository<ClassReadModel>, IClassRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ClassRepository(ApplicationDbContext dbContext, ITenantProvider tenantProvider) : base(dbContext, tenantProvider)
    {
        _dbContext = dbContext;
    }
    //ClassRepository kế thừa Repositoy của con Core và truyền vào dữ liệu có kiểu là ClassRealMode.

    // và kế thừa interface là IClassRepository.
}