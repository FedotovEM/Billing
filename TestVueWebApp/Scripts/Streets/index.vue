<template>
    <div id="street">
        <h1>Streets</h1>
        <p>
            <a :href="CreateStreetUrl">Create New</a>
        </p>
        <select id="IdCombobox">
            <option>StreetName</option>
        </select>

        <input type="text" id="Input" onkeyup="Search()" placeholder="Search" />

        <table id="table-id" class="table">
            <thead>
                <tr>
                    <th data-type="string">
                        StreetName
                    </th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="item in Streets">
                    <td>
                        {{item.StreetName}}
                    </td>
                    <td>
                        <a :href="EditStreetUrl+'/'+item.StreetCd">Edit</a> |
                        <a :href="DetailsStreetUrl+'/'+item.StreetCd">Details</a> |
                        <a :href="DeleteStreetUrl+'/'+item.StreetCd">Delete</a>
                    </td>
                </tr>
            </tbody>
        </table>

    </div>

</template>

<script>
    export default {
        name: "index-component",
        props: {
            CreateStreetUrl: String,
            DeleteStreetUrl: String,
            EditStreetUrl: String,
            DetailsStreetUrl: String,
            Streets: Array
        }
    };
</script>