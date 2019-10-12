using System.Collections.Generic;

namespace MonoTest
{
    public class MonoFunctions
    {
        public static MonoFunctions Instance { get; } = new MonoFunctions();

        private MonoFunctions()
        {
            Init();
        }

        public Dictionary<int, string> FunctionDictionary = new Dictionary<int, string>();

        private void Init()
        {
            FunctionDictionary.Add(1, "mono_class_get");
            FunctionDictionary.Add(2, "mono_class_get_name");
            FunctionDictionary.Add(3, "mono_class_get_namespace");
            FunctionDictionary.Add(4, "mono_assembly_get_image");
            FunctionDictionary.Add(5, "mono_class_get_nested_types");
            FunctionDictionary.Add(6, "mono_assembly_open");
            FunctionDictionary.Add(7, "mono_assembly_load_from_full");
            FunctionDictionary.Add(8, "mono_class_get_fields");
            FunctionDictionary.Add(9, "mono_domain_get");
            FunctionDictionary.Add(10, "mono_gchandle_free");
            FunctionDictionary.Add(11, "mono_field_get_value_object");
            FunctionDictionary.Add(12, "mono_gchandle_new");
            FunctionDictionary.Add(13, "mono_image_open_from_data_with_name");
            FunctionDictionary.Add(14, "mono_image_get_table_rows");
            FunctionDictionary.Add(15, "mono_method_signature");
            FunctionDictionary.Add(16, "mono_class_get_type");
            FunctionDictionary.Add(17, "mono_thread_interruption_checkpoint");
            FunctionDictionary.Add(18, "mono_thread_detach");
            FunctionDictionary.Add(19, "mono_class_get_methods");
            //165B2 - mono_class_get_nesting_type
            //165B2 - mono_image_get_guid
            FunctionDictionary.Add(20, "mono_class_get_nesting_type");
            //3875D - mono_event_get_raise_method
            //3875D - mono_jit_info_get_code_size
            //3875D - mono_method_get_name
            //3875D - mono_property_get_flags
            FunctionDictionary.Add(21, "mono_event_get_raise_method");
            FunctionDictionary.Add(22, "mono_object_unbox");
            FunctionDictionary.Add(23, "mono_type_get_object");
            FunctionDictionary.Add(24, "mono_object_get_class");
            FunctionDictionary.Add(25, "mono_string_new");
            FunctionDictionary.Add(26, "mono_runtime_invoke");
            FunctionDictionary.Add(27, "mono_thread_current");
            FunctionDictionary.Add(28, "mono_class_get_parent");
            FunctionDictionary.Add(29, "mono_get_root_domain");
            //16635 - mono_event_get_name
            //16635 - mono_field_get_name
            //16635 - mono_method_get_token
            //16635 - mono_property_get_name
            FunctionDictionary.Add(30, "mono_event_get_name");
            FunctionDictionary.Add(31, "mono_thread_attach");
            FunctionDictionary.Add(32, "mono_string_to_utf8");
            FunctionDictionary.Add(33, "mono_thread_get_main");
            FunctionDictionary.Add(34, "mono_array_addr_with_size");
            FunctionDictionary.Add(35, "mono_array_element_size");
            FunctionDictionary.Add(36, "mono_object_get_virtual_method");
        }
    }
}
