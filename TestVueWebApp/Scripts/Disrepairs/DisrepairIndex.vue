<template>
    <div id="disrepair">
        <h1>Disrepairs</h1>
        <p>
            <a :href="CreateDisrepairsUrl">Create New</a>
        </p>

        <select id="IdCombobox">
            <option>FailureName</option>
        </select>

        <input type="text" id="Input" onkeyup="Search()" placeholder="Search" />

        <table id="table-id" class="table">
            <thead>
                <tr>
                    <th data-type="string">
                        FailureName
                    </th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="item in Disrepairs">
                    <td>
                        {{item.FailureName}}
                    </td>
                    <td>
                        <a :href="EditDisrepairsUrl+'/'+item.FailureCd">Edit</a> |
                        <a :href="DetailsDisrepairsUrl+'/'+item.FailureCd">Details</a> |
                        <a :href="DeleteDisrepairsUrl+'/'+item.FailureCd">Delete</a>
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