// import React from "react";
// import { useFormik } from "formik";
// import * as yup from "yup";
// import { TextField } from "@mui/material";
// import { DatePicker } from "@mui/x-date-pickers";

// interface FormData {
//   name: string;
//   email: string;
//   birthdate: Date;
// }

// const validationSchema = yup.object().shape({
//   name: yup.string().required("Name is required"),
//   email: yup.string().email("Invalid email").required("Email is required"),
//   birthdate: yup.date().required("Birthdate is required"),
// });

// const MyForm: React.FC = () => {
//   const initialValues: FormData = {
//     name: "",
//     email: "",
//     birthdate: new Date(),
//   };

//   const formik = useFormik<FormData>({
//     initialValues,
//     validationSchema,
//     onSubmit: (values) => {
//       alert(JSON.stringify(values, null, 2));
//     },
//   });

//   return (
//     <form onSubmit={formik.handleSubmit}>
//       <TextField
//         id="name"
//         name="name"
//         label="Name"
//         value={formik.values.name}
//         onChange={formik.handleChange}
//         onBlur={formik.handleBlur}
//         error={formik.touched.name && Boolean(formik.errors.name)}
//         helperText={formik.touched.name && formik.errors.name}
//       />

//       <TextField
//         id="email"
//         name="email"
//         label="Email"
//         value={formik.values.email}
//         onChange={formik.handleChange}
//         onBlur={formik.handleBlur}
//         error={formik.touched.email && Boolean(formik.errors.email)}
//         helperText={formik.touched.email && formik.errors.email}
//       />

//       <DatePicker
//         id="birthdate"
//         name="birthdate"
//         label="Birthdate"
//         value={formik.values.birthdate}
//         onChange={(date) => formik.setFieldValue("birthdate", date)}
//         onBlur={formik.handleBlur}
//         inputFormat="dd/MM/yyyy"
//         renderInput={(params) => (
//           <TextField
//             {...params}
//             error={formik.touched.birthdate && Boolean(formik.errors.birthdate)}
//             helperText={formik.touched.birthdate && formik.errors.birthdate}
//           />
//         )}
//       />

//       <button type="submit">Submit</button>
//     </form>
//   );
// };

// export default MyForm;
