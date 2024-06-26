﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListApp.Data.Models
{
	public class Comment
	{
		public int Id { get; set; }
		public string Text { get; set; }
		public DateTime CreatedDate { get; set; }
		public int TaskId { get; set; }
		public TodoTask Task { get; set; }

	}
}
