using PiProject.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiProject.service
{
	public interface ICollaboratorService
	{
		IEnumerable<t_evaluationtest> DisplayTests(t_collaborator collaborator, string type);
	}
}
