public Task<IEnumerable<T>> GetItemsAsync(
    Func<T, bool> queryPredicate,
    Func<T, int> orderDescendingPredicate,
    int page = 1, int pageSize = 10
)
{
    var result = _items
        .Where(queryPredicate) // filter
        .OrderByDescending(orderDescendingPredicate) // sort
        .Skip(page * pageSize) // find page
        .Take(pageSize); // take items

    return Task<IEnumerable<T>>.FromResult(result);
}