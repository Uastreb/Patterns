using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorHandler
{
    public class Error
    {
        public string Text { get; set; }
        public int Code { get; set; }

        public Error(int code, string text)
        {
            Text = text;
            Code = code;
        }

        public override string ToString()
        {
            return $"{nameof(Code)}: {Code}\n{nameof(Text)}: {Text}\n";
        }
    }

    public class ValidationService
    {
        protected ValidationService _next;
        protected List<Error> _errors;

        public ValidationService()
        {
            _errors = new List<Error>();
        }

        public void Add(ValidationService vs)
        {
            if (_next != null)
            {
                _next.Add(vs);
            }
            else
            {
                _next = vs;
            }
        }

        public virtual bool CheckErrors(bool performAllCheck = true)
        {
            if (_next != default)
            {
                return _next.CheckErrors(performAllCheck);
            }

            return !_errors.Any();
        }

        public IList<Error> GetErrors()
        {
            var nextErrors = _next?.GetErrors();

            if (nextErrors != default)
            {
                _errors.AddRange(nextErrors);
            }

            return _errors;
        }
    }

    public class CheckStringValidation : ValidationService
    {
        private Func<string, Error> _checkTextFunc;
        private string _text;

        public CheckStringValidation(Func<string, Error> func, string text)
          : base()
        {
            _checkTextFunc = func;
            _text = text;
        }

        public override bool CheckErrors(bool performAllCheck = true)
        {
            var error = _checkTextFunc(_text);
            if (error != default)
            {
                _errors.Add(error);
            }

            if (!performAllCheck && error != default)
            {
                return false;
            }

            return base.CheckErrors();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string testString = "Validation faild";

            var validationService = new ValidationService();

            validationService.Add(new CheckStringValidation((string text) =>
            {
                if (text.Length > 6)
                {
                    return new Error(200, testString);
                }

                return default;

            }, "Check validation"));

            validationService.Add(new CheckStringValidation((string text) =>
            {
                if (char.IsUpper(text[0]))
                {
                    return new Error(201, testString);
                }

                return default;

            }, "Check validation"));

            validationService.Add(new CheckStringValidation(NameValidationFunc, testString));

            var result = validationService.CheckErrors(false);
            var errors = validationService.GetErrors();

            foreach (var error in errors)
            {
                Console.WriteLine(error);
            }

            Console.ReadLine();
        }

        public static Func<string, Error> NameValidationFunc =>
            new Func<string, Error>((name) =>
            {
                if (!string.IsNullOrEmpty(name))
                {
                    return new Error(202, "Validation faild");
                }

                return default;
            });
    }
}
