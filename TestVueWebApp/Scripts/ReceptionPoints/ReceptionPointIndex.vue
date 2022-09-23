<template>
    <div id="reception">
        </style>
        <h1>ReceptionPoints</h1>
        <p>
            <a :href="CreateReceptionUrl">Create New</a>
        </p>
        <select id="IdCombobox">
            <option>ReceptionName</option>
        </select>

        <input type="text" id="Input" onkeyup="Search()" placeholder="Search" />

        <table id="table-id" class="table">
            <thead>
                <tr>
                    <th data-type="string">
                        ReceptionName
                    </th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="item in Receptions">
                    <td>
                        {{item.ReceptionName}}
                    </td>
                    <td>
                        <a :href="EditReceptionUrl+'/'+item.ReceptionPointCd">Edit</a> |
                        <a :href="DetailsReceptionUrl+'/'+item.ReceptionPointCd">Details</a> |
                        <a :href="DeleteReceptionUrl+'/'+item.ReceptionPointCd">Delete</a>
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
            CreateReceptionUrl: String,
            DeleteReceptionUrl: String,
            EditReceptionUrl: String,
            DetailsReceptionUrl: String,
            Receptions: Array
        }
    };
</script>