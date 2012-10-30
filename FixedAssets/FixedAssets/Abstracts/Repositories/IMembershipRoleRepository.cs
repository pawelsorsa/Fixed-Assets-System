﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EF_ZMTdbEntities;

namespace FixedAssets.Abstracts.Repositories
{
    public interface IMembershipRoleRepository
    {
        IQueryable<MembershipRole> MembershipRoles { get; }
    }
}
