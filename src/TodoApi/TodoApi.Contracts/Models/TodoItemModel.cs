﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TodoApi.Contracts.Models
{
    public class TodoItemModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public bool IsComplete { get; set; }
    }
}
