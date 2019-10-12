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

        public Dictionary<int, string> Dictionary = new Dictionary<int, string>();

        private void Init()
        {
            Dictionary.Add(1, "mono_class_get");
            Dictionary.Add(2, "mono_class_get_name");
            Dictionary.Add(3, " mono_class_get_namespace");
            Dictionary.Add(4, "mono_assembly_get_image");
            Dictionary.Add(5, "mono_class_get_nested_types");
            Dictionary.Add(6, "mono_assembly_open");
            Dictionary.Add(7, "mono_assembly_load_from_full");
            Dictionary.Add(8, "mono_class_get_fields");
            Dictionary.Add(9, "mono_domain_get");
            Dictionary.Add(10, "mono_gchandle_free");
            Dictionary.Add(11, "mono_field_get_value_object");
            Dictionary.Add(12, "mono_gchandle_new");
            Dictionary.Add(13, "mono_image_open_from_data_with_name");
            Dictionary.Add(14, "mono_image_get_table_rows");
            Dictionary.Add(15, "mono_method_signature");
            Dictionary.Add(16, "mono_class_get_type");
            Dictionary.Add(17, "mono_thread_interruption_checkpoint");
            Dictionary.Add(18, "mono_thread_detach");
            Dictionary.Add(19, "mono_class_get_methods");
            //mono_class_get_nesting_type 还有另外1个 mono_image_get_guid
            Dictionary.Add(20, "mono_class_get_nesting_type");
            //mono_event_get_raise_method 还有另外3个
            Dictionary.Add(21, "mono_event_get_raise_method");
            Dictionary.Add(22, "mono_object_unbox");
            Dictionary.Add(23, "mono_type_get_object");
            Dictionary.Add(24, "mono_object_get_class");
            Dictionary.Add(25, "mono_string_new");
            Dictionary.Add(26, "mono_runtime_invoke");
            Dictionary.Add(27, "mono_thread_current");
            Dictionary.Add(28, "mono_class_get_parent");
            Dictionary.Add(29, "mono_get_root_domain");
            //mono_event_get_name 还有另外3个
            Dictionary.Add(30, "mono_event_get_name");
            Dictionary.Add(31, "mono_thread_attach");
            Dictionary.Add(32, "mono_string_to_utf8");
            Dictionary.Add(33, "mono_thread_get_main");
            Dictionary.Add(34, "mono_array_addr_with_size");
            Dictionary.Add(35, "mono_array_element_size");
            Dictionary.Add(36, "mono_object_get_virtual_method");
        }
    }
}
