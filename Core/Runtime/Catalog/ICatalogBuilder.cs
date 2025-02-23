using UnityEngine.GameFoundation.Configs;
using UnityEngine.Promise;
#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif

namespace UnityEngine.GameFoundation
{
    /// <summary>
    ///     The builder of all the runtime static data of Game Foundation.
    ///     It is given to the data layer so it can configure the data based on its
    ///     internal data structure, that Game Foundation doesn't need to know.
    /// </summary>
    #if ODIN_INSPECTOR
    [HideReferenceObjectPicker]
    #endif
    public interface ICatalogBuilder
    {
        /// <summary>
        ///     Creates a new <typeparamref name="TCatalogItem"/> instance.
        /// </summary>
        /// <typeparam name="TCatalogItem">
        ///     The type of the item to create.
        /// </typeparam>
        /// <param name="key">
        ///     The identifier of the <typeparamref name="TCatalogItem"/> instance to create.
        /// </param>
        /// <returns>
        ///     The new <typeparamref name="TCatalogItem"/> instance.
        /// </returns>
        public TCatalogItem Create<TCatalogItem>(string key)
            where TCatalogItem : CatalogItemConfig, new();

        /// <summary>
        ///     Gets a new Tag instance by its key.
        /// </summary>
        /// <param name="key">
        ///     The identifier of the tag.
        /// </param>
        /// <param name="create">
        ///     Creates the tag config if not found.
        /// </param>
        /// <returns>
        ///     The <see cref="Tag"/> instance.
        /// </returns>
        public TagConfig GetTag(string key, bool create = true);

        /// <summary>
        ///     Aggregate current data of this builder to create new catalogs.
        /// </summary>
        /// <returns>
        ///     Return a promise handle to track the operation's status.
        ///     The operation's result is a tuple of a new <see cref="Catalog"/>
        ///     and a new <see cref="TagCatalog"/> if it is successful.
        /// </returns>
        public Deferred<(Catalog, TagCatalog)> Build();
    }
}