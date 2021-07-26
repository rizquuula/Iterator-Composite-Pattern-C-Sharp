﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IteratorPattern.Models;

namespace IteratorPattern.Business {
  class IteratorDepartmentOfArt : IIterator{
    private List<Student> _members;
    private int _position = 0;
    internal IteratorDepartmentOfArt(List<Student> members) {
      _members = members;
    }
    bool IIterator.HasNext() {
      if (_members.Count > _position) {
        return true;
      }
      else {
        return false;
      }
    }
    object IIterator.Next() {
      Student student = _members[_position];
      _position++;
      return student;
    }
    void IIterator.Remove() {
      if (_position <= 0) {
        throw new IndexOutOfRangeException("Can't remove am item before Next() is called");
      }
      else if (_members[_position-1] != null) {
        for (int i = _position-1; _position-1 <= _members.Count - 1; i++) {
          _members[i] = _members[i + 1];
        }
      }
      else {
        // nothing
      }
    }
  }
}
