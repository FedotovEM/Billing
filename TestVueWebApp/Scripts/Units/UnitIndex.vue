<template>
    <div id="unit">
        <h1>Units</h1>
        <p>
            <a :href="CreateUnitUrl">Create New</a>
        </p>
        <select id="IdCombobox">
            <option>UnitsName</option>
        </select>

        <input type="text" id="Input" onkeyup="Search()" placeholder="Search" />

        <table id="table-id" class="table">
            <thead>
                <tr>
                    <th data-type="string">
                        UnitName
                    </th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="item in Units">
                    <td>
                        {{item.UnitsName}}
                    </td>
                    <td>
                        <a :href="EditUnitUrl+'/'+item.UnitCd">Edit</a> |
                        <a :href="DetailsUnitUrl+'/'+item.UnitCd">Details</a> |
                        <a :href="DeleteUnitUrl+'/'+item.UnitCd">Delete</a>
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
            CreateUnitUrl: String,
            DeleteUnitUrl: String,
            EditUnitUrl: String,
            DetailsUnitUrl: String,
            Units: Array
        }
    };
</script>