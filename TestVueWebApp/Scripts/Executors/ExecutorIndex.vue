<template>
    <div id="executor">
        <h1>Executors</h1>
        <p>
            <a :href="CreateExecutorUrl">Create New</a>
        </p>
        <select id="IdCombobox">
            <option>Fio</option>
        </select>

        <input type="text" id="Input" onkeyup="Search()" placeholder="Search" />

        <table id="table-id" class="table">
            <thead>
                <tr>
                    <th data-type="string">
                        FIO
                    </th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="item in Executors">
                    <td>
                        {{item.Fio}}
                    </td>
                    <td>
                        <a :href="EditExecutorUrl+'/'+item.ExecutorCd">Edit</a> |
                        <a :href="DetailsExecutorUrl+'/'+item.ExecutorCd">Details</a> |
                        <a :href="DeleteExecutorUrl+'/'+item.ExecutorCd">Delete</a>
                    </td>
                </tr>
            </tbody>
        </table>

    </div>

</template>

<script>
    export default {
        name: "executor-index-component",
        props: {
            CreateExecutorUrl: String,
            DeleteExecutorUrl: String,
            EditExecutorUrl: String,
            DetailsExecutorUrl: String,
            Executors: Array
        }
    };
</script>