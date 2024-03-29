﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IteratorPattern.Models;

namespace IteratorPattern.Business {
  class DepartmentOfEngineering : IDepartment {
    int _maxMembers = 5;
    int _numberOfItems = 0;
    Student[] _members;
    internal DepartmentOfEngineering() {
      _members = new Student[_maxMembers];
      AddMember("Gon", 23, 170, 71);
      AddMember("Joo", 22, 175, 75);
      AddMember("Bim", 23, 168, 67);
      AddMember("Bim", 21, 166, 64);
    }

    void AddMember(string name, int age, int height, int weight) {
      Student newStudent = new Student(name, age, height, weight);
      if (_numberOfItems < _maxMembers) {
        _members[_numberOfItems] = newStudent;
        _numberOfItems++;
      }
      else {
        Console.WriteLine("Members limit reached.");
      }
    }

    IEnumerable IDepartment.CreateIterator() {
      IEnumerable componentList = new StudentEnumerable(_members);
      IEnumerator componentEnumerator = componentList.GetEnumerator();
      while (componentEnumerator.MoveNext()) {
        yield return (Component)componentEnumerator.Current;
      }
    }

    object IDepartment.GetMembers() {
      return _members;
    }
  }
}
