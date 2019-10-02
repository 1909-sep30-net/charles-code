using System;
using System.Collections.Generic;
using System.Text;

namespace DogApplication
{
    internal class Dog
    {
        //access modifiers    not all data should be visible from everywhere. 
        //different responsibilities for different parts of code and living in those responsibilities
        //public -- everyone can see
        //internal -- everyone in same assembly (project) can see
        //protected -- all subclasses of dog can see (even if it is in another project).
        //private -- only this class can see.
        //
        // ALSO
        //
        //  A venn diagram can adequately describe what parts of a project can access these...
        // protected internal
        // private protected
        //


        
        //Private is default for all class members.

        // For classes themeselves, internal is default, public and internal is even possible).

            //try to be explicit in declarations.

        //fields
        public string name;
        public int age;

        //better than public fields, are getters and setters methods (mutator and accessors), much like java
        //but better than that are "Properties".  Use less code.

        //public int Age { get; set; }   // <-- this is an auto-property, or auto-implemented property.
                                        // has a hidden backing field.


        //what it looks like with actual validation.
        public int aGE
        {
            get
            {
                return age;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
                age = value;
            }
        }


        //constructor
        // Always at least one constructor, default is ... blank.  Dog() { }
        public Dog(string name, int age)
        {
            //in the class, "this" is a way to refger to the current instance being considered.

            //validation
            
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            this.SetName(name);

            if (age < 0)
            {
               throw new ArgumentOutOfRangeException("age");
                // an exception is how we represent and handle "errors" durring runtime.
                // can be thown from a particular point in code, often handled by a try-catch.
            }

            this.age = age;
        }

        public string GetName()
        {
            return name;
        }

        public void SetName(string name)
        {
            //validation put here in the setter
            //all "consumers" don't have to worry... as the functionality for validation is here.

            this.name = name;
        }
    }
}
