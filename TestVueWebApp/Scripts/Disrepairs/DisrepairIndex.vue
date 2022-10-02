<template>
    <div id="disrepair">
        <h1>Неисправности</h1>
        <p>
            <a :href="CreateDisrepairsUrl">Добавить новую запись</a>
        </p>

        <select id="IdCombobox">
            <option>Наименование неисправности</option>
        </select>

        <input type="text" id="Input" onkeyup="Search()" placeholder="Поиск" />

        <table id="table-id" class="table">
            <thead>
                <tr>
                    <th data-type="string">Наименование неисправности</th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="item in Disrepairs">
                    <td>
                        {{item.FailureName}}
                    </td>
                    <td>
                        <a :href="EditDisrepairsUrl+'/'+item.FailureCd">Изменить</a> |
                        <a :href="DetailsDisrepairsUrl+'/'+item.FailureCd">Подробности</a> |
                        <a :href="DeleteDisrepairsUrl+'/'+item.FailureCd">Удалить</a>
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