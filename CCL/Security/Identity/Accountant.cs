﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CCL.Security.Identity
{
	public class Accountant
		: User
	{
		public Accountant(int userId, string name, int userId1)
			: base(userId, name, userId1, nameof(Accountant))
		{
		}
	}
}