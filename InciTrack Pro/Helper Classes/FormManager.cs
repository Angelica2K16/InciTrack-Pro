using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InciTrack_Pro.Helper_Classes
{
    public static class FormManager
    {

        public static void ShowOrActivateForm<T>(Form activeForm, Func<T> formFactory) where T : Form
        {
            T? targetForm = Application.OpenForms.OfType<T>().FirstOrDefault();

            if (targetForm is not null)
            {
                SetFormLocation(targetForm, activeForm); // Pass the form, not bounds
                targetForm.Show();
                targetForm.BringToFront();
                targetForm.Activate();
            }
            else
            {
                T newForm = formFactory();
                SetFormLocation(newForm, activeForm);
                newForm.Show();
                newForm.BringToFront();
                newForm.Activate();
            }

            ////Close or hide the active form safely
            //if (activeForm != Application.OpenForms[0]) // Not main form
            //{
            //    activeForm.Close();
            //}
            //else
            //{
            //    activeForm.Hide(); // Hide main form to keep app alive
            //}

            activeForm.Hide();

            targetForm.FormClosed += (s, e) => { activeForm.Show(); };


        }


        public static void SetFormLocation(Form target, Form reference)
        {
            target.StartPosition = FormStartPosition.Manual;

            // Get the screen where the reference form is located
            Screen referenceScreen = Screen.FromControl(reference);

            // Calculate center position relative to the reference form
            int x = reference.Location.X + (reference.Width - target.Width) / 2;
            int y = reference.Location.Y + (reference.Height - target.Height) / 2;

            // Ensure the target form stays within the bounds of the reference screen
            Rectangle workingArea = referenceScreen.WorkingArea;

            x = Math.Max(workingArea.Left, Math.Min(x, workingArea.Right - target.Width));
            y = Math.Max(workingArea.Top, Math.Min(y, workingArea.Bottom - target.Height));

            target.Location = new Point(x, y);


        }
    }
}
