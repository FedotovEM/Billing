<template>
    <div id="disrepair">
        <h1>�������������</h1>
        <p>
            <a :href="CreateDisrepairsUrl">�������� ����� ������</a>
        </p>

        <select id="IdCombobox">
            <option>������������ �������������</option>
        </select>

        <input type="text" id="Input" onkeyup="Search()" placeholder="�����" />

        <table id="table-id" class="table">
            <thead>
                <tr>
                    <th data-type="string">������������ �������������</th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="item in Disrepairs">
                    <td>
                        {{item.FailureName}}
                    </td>
                    <td>
                        <a :href="EditDisrepairsUrl+'/'+item.FailureCd">��������</a> |
                        <a :href="DetailsDisrepairsUrl+'/'+item.FailureCd">�����������</a> |
                        <a :href="DeleteDisrepairsUrl+'/'+item.FailureCd">�������</a>
                    </td>
                </tr>
            </tbody>
        </table>

    </div>

</template>

<script>
    export default {
        name: "disrepair-index-component",
        props: {
            CreateDisrepairsUrl: String,
            DeleteDisrepairsUrl: String,
            EditDisrepairsUrl: String,
            DetailsDisrepairsUrl: String,
            Disrepairs: Array
        }
    };
</script>